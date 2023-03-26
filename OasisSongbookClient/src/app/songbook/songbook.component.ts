import { Component, Inject, Optional } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Dialog } from '@angular/cdk/dialog';
import { AppendToSongbookCommand, ArrangementEntry, ReorderCommand, Song, SongbookService } from 'src/shared/api-client';
import { EditSongStyleDialogComponent } from '../songs-collection/edit-song-style-dialog/edit-song-style-dialog.component';
import { API_CURRENT_SONGBOOK_ID, API_CURRENT_USER_ID } from 'src/shared/environment-consts';

@Component({
  selector: 'songbook',
  templateUrl: './songbook.component.html',
  styleUrls: ['./songbook.component.scss']
})
export class SongbookComponent {
  showFiller = false;
  selectedSongs: Song[] = [];

  constructor(public dialog: Dialog,
    private service: SongbookService,
    @Inject(API_CURRENT_USER_ID) private currentUserId?: string,
    @Inject(API_CURRENT_SONGBOOK_ID) private currentSongbookId?: string) { }

  drop(event: CdkDragDrop<Song[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
      let reorderCommand = {
        songbookId: this.currentSongbookId,
        userId: this.currentUserId,
        songId: event.container.data[event.previousIndex]._id,
        newOrder: event.currentIndex
      } as ReorderCommand;
      this.service.reorder(reorderCommand);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
      let appendCommand = {
        songbookId: this.currentSongbookId,
        userId: this.currentUserId,
        songId: event.container.data[event.currentIndex]._id,
        order: event.currentIndex
      } as AppendToSongbookCommand;
      this.service.append(appendCommand);
    }

  }

  getArrangement(arrangement: ArrangementEntry[]): string {
    return arrangement.map(e => e.note!).reduce((sum, entry) => sum += ` ${entry}`);
  }

  // getArrangementForLine(song: Song, verseIndex: number, lineIndex: number): string {
  //   let lineArrangement = song.arrangements[0].verse[verseIndex].entries?.map(e => e.note);
  //   let arrangement = '';
  //   lineArrangement.forEach(element => {
  //     arrangement += element;
  //   });
  // }

  deleteFromSongbook(item: string) {
    this.selectedSongs = this.selectedSongs.filter(i => i.title !== item);
  }

  editSongStyle(id: string) {
    const dialogRef = this.dialog.open<string>(EditSongStyleDialogComponent, {
      width: '250px',
      data: { name: 'asdf' },
    });

    dialogRef.closed.subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
