import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocalizationService {
  currLanguage: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(localStorage.getItem('language'));

  constructor() { }

  setLanguage(language: string){
    localStorage.setItem('language', language);
  }

  getLanguage(){
    return localStorage.getItem('language');
  }
}
