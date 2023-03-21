import { Component } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Dialog } from '@angular/cdk/dialog';
import { EditSongStyleDialogComponent } from './songs-collection/edit-song-style-dialog/edit-song-style-dialog.component';
import { Song } from 'src/shared/api-client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  showFiller = false;
  selectedSongs: Song[] = [];

  constructor(public dialog: Dialog) { }

  drop(event: CdkDragDrop<Song[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }
  }

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
