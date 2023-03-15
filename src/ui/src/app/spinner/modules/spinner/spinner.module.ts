import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from '../../feature/spinner/spinner.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SpinnerInterceptor } from '../../interceptors/spinner.interceptor';

@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  exports: [
    SpinnerComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SpinnerInterceptor,
      multi: true,
   },
  ]
})
export class SpinnerModule { }
