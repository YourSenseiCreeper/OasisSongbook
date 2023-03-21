import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { DragDropModule } from '@angular/cdk/drag-drop';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from 'src/shared/shared.module';
import { EditSongStyleDialogComponent } from '../songs-collection/edit-song-style-dialog/edit-song-style-dialog.component';
import { SongsCollectionSidenavComponent } from '../songs-collection/songs-collection-sidenav/songs-collection-sidenav.component';
import { SongbookEditorComponent } from './songbook-editor/songbook-editor.component.component';
import { SongbookRoutingModule } from './songbook-routing.module';
import { SongbookComponent } from './songbook.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    SongbookComponent,
    SongsCollectionSidenavComponent,
    EditSongStyleDialogComponent,
    SongbookEditorComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SongbookRoutingModule,
    MatSidenavModule,
    MatButtonModule,
    DragDropModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [SongbookComponent]
})
export class SongbookModule { }
