import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShareService } from '../share.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private shareService: ShareService) { }
  public createAccount(data : any): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/friend/Create-By-List`;
    return this.shareService.postHttpClient(url, data);
  }
  public getListFriend(userId: string, skip:number, take : number): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/friend/Get-List-Friend?idUser=${userId}&skip=${skip}&take=${take}`;
    return this.shareService.returnHttpClientGet(url);
  }
  public updateProfile(profileName: string, dto : any): Observable<any> {
    const url = `${this.shareService.REST_API_SERVER}/api/client-profile?profileName=${profileName}`;
    return this.shareService.putHttpClient(url, dto);
  }
}
