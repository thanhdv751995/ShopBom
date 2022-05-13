import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  listIssues;
  listStatus;
  projectId;
  id;
  filterStatus;
  constructor() { }

  ngOnInit(): void {
  }
  onChangeProject(a){

  }
  onChangeStatus(a){}
}
