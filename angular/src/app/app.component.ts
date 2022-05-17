import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { ShareService } from './services/share.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  isCollapsed = false;
  public app = "product";
  public product = false;
  public customer = false;
  constructor(public router: Router,
    public shareService: ShareService
  ) { }
  ngOnInit(): void {

  }

}
