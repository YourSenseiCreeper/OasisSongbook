import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { environment } from 'src/environment/environment';
import { SongService, SongbookService, API_BASE_URL } from './api-client';
import { API_CURRENT_SONGBOOK_ID, API_CURRENT_USER_ID } from './environment-consts';

@NgModule({
  declarations: [],
  imports: [
    // CommonModule,
    HttpClientModule
  ],
  providers: [
    SongService,
    SongbookService,
    { provide: API_BASE_URL, useFactory: () => environment.baseApiUrl },
    { provide: API_CURRENT_USER_ID, useFactory: () => environment.currentUserId },
    { provide: API_CURRENT_SONGBOOK_ID, useFactory: () => environment.currentSongbookId },
  ],
  bootstrap: [],
  exports: []
})
export class SharedModule { }
