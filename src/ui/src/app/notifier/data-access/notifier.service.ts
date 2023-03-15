import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotifierComponent } from '../feature/notifier/notifier.component';

@Injectable({
  providedIn: 'root'
})
export class NotifierService {

  constructor(private snackBar: MatSnackBar) { }

  showNotification(message: string, messageType: 'ERROR' | 'SUCCESS'){
    this.snackBar.openFromComponent(NotifierComponent,{
      data: {
        message: message,
        type: messageType
      },
      duration: 4000,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: messageType,
    });
  }
}
