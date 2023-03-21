import { Component, EventEmitter, OnDestroy, OnInit } from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { map, Observable, of, startWith, Subject, takeUntil } from 'rxjs';
import { FormControl } from '@angular/forms';
import { Service, Song } from 'src/shared/api-client';

@Component({
  selector: 'songs-collection-sidenav',
  templateUrl: './songs-collection-sidenav.component.html',
  styleUrls: ['./songs-collection-sidenav.component.scss']
})
export class SongsCollectionSidenavComponent implements OnInit, OnDestroy {
  showFiller = false;
  destroy$ = new EventEmitter<any>();
  allSongs: Song[] = [];
  // allSongs: Song[] =
  // [
  //   { id: 1, name: 'Uwielbiam imię Twoje Panie', text: [
  //       'Uwielbiam imię Twoje Panie',
  //       'Wywyższam Cię i daję Ci hodł',
  //       'W przedsionku chwały Twej staję',
  //       'Z radością śpiewam Ci pieśń',
  //       ' ',
  //       'O Panie Jezu, chcę wyznać że',
  //       'Ja kocham Ciebie, Ty zmieniasz mnie',
  //       'Chcę Ci dziękować ze wszystkich sił',
  //       'Dajesz mi Siebie bym na wieki żył'
  //   ]},
  //   { id: 2, name: 'Jezus siłą mą', text: [
  //       "Jezus daje nam zbawienie",
  //       "Jezus daje pokój nam",
  //       "Jemu składam dziękczynienie",
  //       "chwałę z serca mego dam",
  //       " ",
  //       "ref. Jezus siłą mą, Jezus pieśnią mego życia",
  //       "Królem wiecznym On, niepojęty w mocy swej",
  //       "w Nim znalazłem to, czego szukałem do dzisiaj",
  //       "sam mi podał dłoń, bym zwyciężał w każdy dzień",
  //       " ",
  //       "W Jego ranach uzdrowienie",
  //       "W Jego śmierci życia dar",
  //       "Jego krew to oczyszczenie",
  //       "Jego życie chwałą nam"
  //   ]},
  //   { id: 3, name: 'Im hashem', text: []},
  //   { id: 4, name: 'Niechaj zstąpi duch twój', text: [
  //       "Niechaj zstąpi Duch Twój",
  //       "i odnowi ziemię.",
  //       "Życiodajny spłynie deszcz",
  //       "na spragnione serce",
  //       "Obmyj mnie i uświęć mnie",
  //       "uwielbienia niech popłynie pieśń",
  //       "Chwała Jezusowi",
  //       "który za mnie życie dał.",
  //       "Chwała Temu",
  //       "który pierwszy umiłował mnie.",
  //       "Jezus, tylko Jezus Panem jest"
  //   ]}
  // ];

  constructor(private service: Service) {

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
    this.service.songGetAll().pipe(takeUntil(this.destroy$)).subscribe(v => {
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