import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-change-language',
  templateUrl: './change-language.component.html',
  styleUrls: ['./change-language.component.css']
})
export class ChangeLanguageComponent implements OnInit {

  chosenLanguage: string;

  constructor(private translate: TranslateService) {

   }

  ngOnInit() {
  }

  onSubmit() {
    this.translate.setDefaultLang(this.chosenLanguage);
  }

}
