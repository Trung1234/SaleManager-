import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../shared/product.service';
import { Product } from '../models/product';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products$: Observable<Product[]>;
  id: number;

  constructor(private productService: ProductService, private toastr: ToastrService) {

  }


  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.products$ = this.productService.getProducts();
  }
  notify(){
    this.toastr.success("Add to cart succesfully");
  }
}
