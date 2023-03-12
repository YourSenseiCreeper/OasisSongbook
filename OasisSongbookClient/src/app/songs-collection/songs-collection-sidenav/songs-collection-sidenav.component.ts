import { Component } from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { map, Observable, startWith } from 'rxjs';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'songs-collection-sidenav',
  templateUrl: './songs-collection-sidenav.component.html',
  styleUrls: ['./songs-collection-sidenav.component.scss']
})
export class SongsCollectionSidenavComponent {
  showFiller = false;
  allSongs = ['Będę śpiewał Tobie', 'Jezus siłą mą', 'Im hashem', 'Oceans'];

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

  filteredSongs$: Observable<string[]>;

  ngOnInit() {
    this.filteredSongs$ = this.songnameInput.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.allSongs.filter(song => song.toLowerCase().includes(filterValue));
  }
}