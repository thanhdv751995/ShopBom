import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShareService } from '../services/share.service';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {

  isCollapsed = false;
  public app = "product";
  public product = false;
  public customer = false;
  currentRouter;
  curent
  constructor(public router: Router,
    public shareService: ShareService
  ) { }
  ngOnInit(): void {
    this.currentRouter = this.router.url;
    if (this.currentRouter.includes('product')) this.product = true;
    if (this.currentRouter.includes('customer')) this.customer = true;
  
    
  }
  nextRound(nameApp) {
    this.app = nameApp;
    if (this.app == "product") {
      this.router.navigate(['product']);
    }
    if (this.app == "customer") {
      this.router.navigate(['customer']);
    }
  }

}
