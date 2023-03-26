import { Component, EventEmitter, OnDestroy, OnInit } from '@angular/core';
import { Observable, takeUntil } from 'rxjs';
import { Service, Song } from 'src/shared/api-client';

@Component({
  selector: 'song-all-list',
  templateUrl: './song-all-list.component.html',
  styleUrls: ['./song-all-list.component.scss']
})
export class SongAllListComponent implements OnInit, OnDestroy {

  displayedSongs$: Observable<Song[]>;
  destroy$ = new EventEmitter<any>();

  constructor(private songService: Service) {}
  

  ngOnInit(): void {
    this.displayedSongs$ = this.songService.songGetAll().pipe(takeUntil(this.destroy$))
  }

  ngOnDestroy(): void {
    this.destroy$.emit();
  }

}
