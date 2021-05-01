import { Component, EventEmitter, OnInit, OnDestroy } from '@angular/core';
import { Product } from 'src/app/models/product/product.model';
import { MessageService } from 'src/app/services/message/messages.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products!: Product[];
  successMessage='';

  constructor(private productService: ProductService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.productService.getMostPopular().subscribe((res: Product[]) => {
      this.products = res;
    })
    
    this.successMessage = this.messageService.getOrderSuccessMessage();
    this.messageService.setOrderSuccessMessage('');
  }
}
