import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { environment } from 'src/environment/environment';
import { API_BASE_URL, Service, SongbookService } from './api-client';

@NgModule({
  declarations: [],
  imports: [
    // CommonModule,
    HttpClientModule
  ],
  providers: [
    Service,
    SongbookService,
    { provide: API_BASE_URL, useFactory: () => environment.baseApiUrl },
  ],
  bootstrap: [],
  exports: []
})
export class SharedModule { }
