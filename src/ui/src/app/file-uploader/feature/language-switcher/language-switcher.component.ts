import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LocalizationService } from '../../services/localization.service';

@Component({
  selector: 'language-switcher',
  templateUrl: './language-switcher.component.html',
  styleUrls: ['./language-switcher.component.scss']
})
export class LanguageSwitcherComponent implements OnInit {
  languages: string[] = ['UK', 'EN', 'FR'];
  currLanguageCode: string = 'EN';

  constructor(
    private localizationService: LocalizationService,
    private translate: TranslateService
  ) { }

  ngOnInit(): void {
    this.getCurrentLanguage();
  }

  getCurrentLanguage(){
    this.localizationService.currLanguage.subscribe(lang => {
      if (lang && this.languages.includes(lang)){
        this.currLanguageCode = lang;
      }
      else{
        this.currLanguageCode = 'EN';
      }

      this.translate.use(this.currLanguageCode.toLowerCase());
    });
  }

  getLanguages(){
    return this.languages.filter(l => l != this.currLanguageCode);
  }

  onLanguageSelected(code: string){
    this.localizationService.setLanguage(code);
    this.localizationService.currLanguage.next(this.localizationService.getLanguage());
  }
}
