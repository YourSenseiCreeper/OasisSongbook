import { Component, EventEmitter, OnDestroy, OnInit } from '@angular/core';
import { Observable, takeUntil } from 'rxjs';
import { Song, SongService } from 'src/shared/api-client';

@Component({
  selector: 'song-all-list',
  templateUrl: './song-all-list.component.html',
  styleUrls: ['./song-all-list.component.scss']
})
export class SongAllListComponent implements OnInit, OnDestroy {

  displayedSongs$: Observable<Song[]>;
  destroy$ = new EventEmitter<any>();

  constructor(private songService: SongService) {}
  

  ngOnInit(): void {
    this.displayedSongs$ = this.songService.all().pipe(takeUntil(this.destroy$))
  }

  ngOnDestroy(): void {
    this.destroy$.emit();
  }

}
