import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SpinnerService } from '../../data-access/spinner.service';

@Component({
  selector: 'spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent implements OnInit {
  isLoading: Subject<boolean> = this.spinnerService.isLoading;

  constructor(private spinnerService: SpinnerService) { }

  ngOnInit(): void {
  }

}
