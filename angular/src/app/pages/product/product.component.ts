import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'src/app/services/message/message.service';
import { ProductService } from 'src/app/services/products/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  public productForm: FormGroup = new FormGroup({});
  myFiles:string  []  =  [];
  selectedProduct;
  isVisibleAddProduct = false;
  isOkLoadingAddProduct = false;
  listProduct;
  nameProduct;
  priceProduct;
  idColor;
  idSize;
  idProductType;
  listColor;
  listSize;
  listProductType;
  isGetListProductLoading = false;
  idProductAdd;
  constructor(private productService: ProductService,
    private message: MessageService,
    private formBuilder: FormBuilder,

  ) { }

  ngOnInit(): void {

    this.productForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required]),
      price : new FormControl('', [Validators.required]),
      idColor: new FormControl(0),
      idSize: new FormControl(0),
      idProductType: new FormControl(0),
      iMage: new FormControl(''),
     
    });
  }



  ProductChange(a) { }

  createProduct() {
    const data = {
      name: this.nameProduct,
      price: this.nameProduct,
      idColor: this.idColor.toString(),
      idSize: this.idSize.toString(),
      idProductType: this.idProductType.toString()
    };
    this.productService.createProduct(data).subscribe(a => {
      this.message.createMessage('success', 'Create product success!');
    }, err => this.message.createMessage('error',err.error.message))
  }
getListProduct(){

}

  showModalAddProduct(): void {
    this.isVisibleAddProduct = true;
  }
  handleOkAddProduct(): void {
    console.log(this.productForm);
    for (var i = 0; i < this.myFiles.length; i++) { 
      console.log(this.myFiles[i]);
     
    }
    // this.createProduct();
    this.isOkLoadingAddProduct=false;
    this.isVisibleAddProduct = false;
   // this.getListProduct();

  }
  onFileChange(event:any) {
   
    for (var i = 0; i < event.target.files.length; i++) { 
        this.myFiles.push(event.target.files[i]);
    }
}
  handleCancelAddProduct(): void {
    this.isVisibleAddProduct = false;
  }
}
