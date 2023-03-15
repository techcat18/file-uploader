import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploaderComponent } from '../../feature/file-uploader/file-uploader.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { DragDropDirective } from '../../directives/drag-drop.directive';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SpinnerModule } from 'src/app/spinner/modules/spinner/spinner.module';

@NgModule({
  declarations: [
    FileUploaderComponent,
    DragDropDirective
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    SpinnerModule,
    TranslateModule.forRoot()
  ]
})
export class FileUploaderModule { }
