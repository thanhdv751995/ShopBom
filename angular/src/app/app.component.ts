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
  currentRouter;
  public product = false;
  public customer = false;
  constructor(public router: Router,
    private shareService: ShareService
    ) {}
 ngOnInit(): void {
  this.currentRouter = this.router.url;
  if (this.currentRouter.includes('product')) this.product = true;
  if (this.currentRouter.includes('customer')) this.customer = true;
  }
  nextRound(nameApp){
    this.app = nameApp;
    if(this.app == "product"){
      this.router.navigate(['product']);
    }
    if(this.app == "customer"){
      this.router.navigate(['customer']);
    }
  }
}
