import { Component, Inject } from '@angular/core';
import { DialogRef } from '@angular/cdk/dialog';

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'edit-song-style-dialog',
  templateUrl: './edit-song-style-dialog.component.html',
  styleUrls: ['./edit-song-style-dialog.component.scss']
})
export class EditSongStyleDialogComponent {
  // constructor(public dialogRef: DialogRef<string>, @Inject(DialogData) public data: DialogData) {}
  constructor(public dialogRef: DialogRef<string>) {}
}