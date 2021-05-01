import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/product/category.model';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { CategoryService } from 'src/app/services/product/category.service';
import { ProductService } from 'src/app/services/product/product.service';
import { ShoppingCartItemsService } from 'src/app/services/shopping-cart-items/shopping-cart-items.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  categories!: Category[];
  @ViewChild('searchValue') search!: ElementRef;
  @ViewChild('categoryIdValue') categoryId!: ElementRef;
  userLoggedIn!: boolean;
  username = "";
  userId!:string;
  numOfCartItems!:number;


  constructor(private categoryService: CategoryService, private router: Router, private productService: ProductService,
    private userService: UserService,private jwtService:JwtService,private shoppingCartService:ShoppingCartItemsService) { }

  ngOnInit(): void {
    if(localStorage.getItem('jwtToken') != null){
      let jwtToken:any = this.jwtService.getJwtTokenEncrypted();
      this.userId = jwtToken.UserId;
    }

    this.categoryService.get().subscribe((res: Category[]) => {
      this.categories = res;
    })

    if(localStorage.getItem('jwtToken') != null){
      this.shoppingCartService.get(this.userId).subscribe((res:shoppingCartItem[])=>{
        this.numOfCartItems = res.length;
      })
    }

    this.shoppingCartService.newShoppingCartItemNotification.subscribe((data:number)=>{
      this.numOfCartItems = data;
    })
    this.userLoggedIn = this.userService.userLoggedIn();
    
    //notification that user is logged in
    this.userService.userLoggedInNotification.subscribe(() => {
      this.userLoggedIn = this.userService.userLoggedIn();
      
      let jwtToken:any = this.jwtService.getJwtTokenEncrypted();
      this.userId = jwtToken.UserId;
      
    })
  }

  onSearch() {
    let searchValue = this.search.nativeElement.value;
    let categoryId = parseInt(this.categoryId.nativeElement.value);

    if (searchValue.length == 0) {
      searchValue = null
    }

    this.productService.onSearchProduct.emit({ searchValue: searchValue, categoryId: categoryId })

    this.router.navigate([`/product/search/${searchValue}/${categoryId}`])
  }

  onLogout() {
    this.userService.logout();
    this.userLoggedIn = this.userService.userLoggedIn();
    this.numOfCartItems = 0;
    this.router.navigate(['/user/login']);
  }
}
