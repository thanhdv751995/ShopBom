import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShareService } from '../share.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private shareService: ShareService) { }
  public createProduct(data : any): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/app/product`;
    return this.shareService.postHttpClient(url, data);
  }
  public getListProduct(userId: string, skip:number, take : number): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/friend/Get-List-Friend?idUser=${userId}&skip=${skip}&take=${take}`;
    return this.shareService.returnHttpClientGet(url);
  }
  public updateProduct(profileName: string, dto : any): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/client-profile?profileName=${profileName}`;
    return this.shareService.putHttpClient(url, dto);
  }
}
