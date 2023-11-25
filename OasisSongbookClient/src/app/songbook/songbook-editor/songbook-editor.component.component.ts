import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, OnDestroy, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, map, of, startWith, takeUntil } from 'rxjs';
import { Song, SongService } from 'src/shared/api-client';

@Component({
  selector: 'songbook-editor',
  templateUrl: './songbook-editor.component.html',
  styleUrls: ['./songbook-editor.component.scss']
})
export class SongbookEditorComponent implements OnInit, OnDestroy {
  showFiller = false;
  destroy$ = new EventEmitter<any>();
  allSongs: Song[] = [];

  constructor(private service: SongService) {

  }
  ngOnDestroy(): void {
    this.destroy$.emit();
  }

  songnameInput = new FormControl('');
  showedSongs: string[] = [];

  drop(event: CdkDragDrop<string[]>) {
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

  filteredSongs$: Observable<Song[]>;

  ngOnInit() {
    this.service.all().pipe(takeUntil(this.destroy$)).subscribe(v => {
      this.allSongs = v;
      this.filteredSongs$ = of(v);
    });
    this.filteredSongs$ = this.songnameInput.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

  private _filter(value: string): Song[] {
    const filterValue = value.toLowerCase();

    return this.allSongs.filter(song => song.title!.toLowerCase().includes(filterValue));
  }
}