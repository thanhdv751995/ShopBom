import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerService } from 'src/app/services/customers/customer.service';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  public customerForm: FormGroup = new FormGroup({});
  myFiles:string  []  =  [];
  selectedCustomer;
  isVisibleAddCustomer = false;
  isOkLoadingAddCustomer = false;
  listCustomer;
  name;
  phoneNumber;
  idColor;
  idSize;
  address;
  email;
  isGetListCustomerLoading = false;
  constructor(private customerService: CustomerService,
    private message: MessageService,
    private formBuilder: FormBuilder,) { }

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required]),
      phoneNumber : new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      email: new FormControl('')
     
    });
  }

  CustomerChange(a) { }

  getCustomer(customer){}

  createProduct() {
    const data = {
      name: this.name,
      phoneNumber: this.phoneNumber,
      address: this.address,
      email: this.email,
    };
    this.customerService.createCustomer(data).subscribe(a => {
      this.message.createMessage('success', 'Create product success!');
    }, err => this.message.createMessage('error',err.error.message))
  }
getListProduct(){

}

  showModalAddProduct(): void {
    this.isVisibleAddCustomer = true;
  }
  handleOkAddProduct(): void {
    console.log(this.customerForm);
    for (var i = 0; i < this.myFiles.length; i++) { 
      console.log(this.myFiles[i]);
     
    }
    // this.createProduct();
    this.isOkLoadingAddCustomer=false;
    this.isVisibleAddCustomer = false;
   // this.getListProduct();

  }
  onFileChange(event:any) {
   
    for (var i = 0; i < event.target.files.length; i++) { 
        this.myFiles.push(event.target.files[i]);
    }
}
  handleCancelAddProduct(): void {
    this.isVisibleAddCustomer = false;
  }
}
