import { Injectable } from '@angular/core';
import { BehaviorSubject, scan, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  private spinnerSub = new BehaviorSubject<boolean>(false);
  private errSub = new Subject<any>();

  constructor() { }

  errObsv = this.errSub
    .asObservable()
    .pipe(scan((acc, curr) => (acc = acc.concat(curr)), []));

  spinnerObsv = this.spinnerSub.asObservable();

  toggleLoadingSpinner(status: boolean) {
    this.spinnerSub.next(status);
  }

  pushMessage(err: any) {
    this.errSub.next(err);
  }
}
