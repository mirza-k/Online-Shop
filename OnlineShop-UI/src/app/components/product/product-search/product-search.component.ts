import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product/product.model';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product-search',
  templateUrl: './product-search.component.html',
  styleUrls: ['./product-search.component.css']
})
export class ProductSearchComponent implements OnInit {
  //this property will be used only for filtering and only will be used to read data
  allProducts!: Product[];
  filteringProducts!: Product[];
  @ViewChildren('chb') checkboxes!: QueryList<ElementRef>;

  products!: Product[];
  searchValue!: string;
  categoryId!: number;
  message: string = '';
  filteredProducts: Product[] = [];
  filters: { filterName: string, filterValues: number[] }[] = [];

  constructor(private activatedRoute: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void {
    this.searchValue = this.activatedRoute.snapshot.params['searchValue'];
    this.categoryId = this.activatedRoute.snapshot.params["categoryId"];

    this.productService.onSearchProduct.subscribe((data: any) => {
      this.ResetFilters();
      this.categoryId = data.categoryId;
      this.searchValue = data.searchValue;
      this.productService.getBySearch(this.categoryId, this.searchValue).subscribe((res: Product[]) => {
        console.log(this.searchValue);
        this.products = res;
        this.allProducts = res;
        this.setMessageProperty(res);
      })
    })

    this.productService.getBySearch(this.categoryId, this.searchValue).subscribe((res: Product[]) => {
      this.products = res;
      this.allProducts = res;
      this.setMessageProperty(res);
    })
  }

  onGenderCategoryCheckbox(event: any) {
    this.filteringProducts = this.allProducts;

    let isChecked = event.target.checked;
    let checkboxValue = event.srcElement.value;
    let foundFlag = false;
    let tempFilterValues: number[] = [];
    let filterIndex = -1;

    //updating genderCategory object with values
    if (this.filters.length > 0) {
      this.filters.forEach((f, index) => {
        if (f.filterName === 'GenderCategory') {
          filterIndex = index;
          foundFlag = true;

          if (isChecked) {
            this.filters[index].filterValues.push(checkboxValue);
            tempFilterValues = this.filters[index].filterValues;
          } else {
            let indexDelete;
            indexDelete = this.filters[index].filterValues.indexOf(checkboxValue);
            this.filters[index].filterValues.splice(indexDelete, 1);
          }
        }
      })
    }

    //creating genderCategory object and add value to array from checkboxValue
    if (!foundFlag) {
      tempFilterValues.push(checkboxValue);
      this.filters.push({ filterName: 'GenderCategory', filterValues: tempFilterValues })
      filterIndex = this.filters.length - 1;
    }

    this.mainQuery()
    this.products = this.filteringProducts;
    this.filteringProducts = this.allProducts;
  }

  onBrandCheckbox(event: any) {
    this.filteringProducts = this.allProducts;

    let isChecked = event.target.checked;
    let checkboxValue = event.srcElement.value;
    let foundFlag = false;
    let tempFilterValues: number[] = [];
    let filterIndex = -1;

    //updating genderCategory object with values
    if (this.filters.length > 0) {
      this.filters.forEach((f, index) => {
        if (f.filterName === 'Brand') {
          filterIndex = index;
          foundFlag = true;

          if (isChecked) {
            this.filters[index].filterValues.push(checkboxValue);
            tempFilterValues = this.filters[index].filterValues;
          } else {
            let indexDelete;
            indexDelete = this.filters[index].filterValues.indexOf(checkboxValue);
            this.filters[index].filterValues.splice(indexDelete, 1);
          }
        }
      })
    }

    //creating genderCategory object and add value to array from checkboxValue
    if (!foundFlag) {
      tempFilterValues.push(checkboxValue);
      this.filters.push({ filterName: 'Brand', filterValues: tempFilterValues })
      filterIndex = this.filters.length - 1;
    }

    this.mainQuery()
    this.products = this.filteringProducts;
    this.filteringProducts = this.allProducts;
  }

  onColorCheckbox(event: any) {
    this.filteringProducts = this.allProducts;

    let isChecked = event.target.checked;
    let checkboxValue = event.srcElement.value;
    let foundFlag = false;
    let tempFilterValues: number[] = [];
    let filterIndex = -1;

    //updating genderCategory object with values
    if (this.filters.length > 0) {
      this.filters.forEach((f, index) => {
        if (f.filterName === 'Color') {
          filterIndex = index;
          foundFlag = true;

          if (isChecked) {
            this.filters[index].filterValues.push(checkboxValue);
            tempFilterValues = this.filters[index].filterValues;
          } else {
            let indexDelete;
            indexDelete = this.filters[index].filterValues.indexOf(checkboxValue);
            this.filters[index].filterValues.splice(indexDelete, 1);
          }
        }
      })
    }

    //creating genderCategory object and add value to array from checkboxValue
    if (!foundFlag) {
      tempFilterValues.push(checkboxValue);
      this.filters.push({ filterName: 'Color', filterValues: tempFilterValues })
      filterIndex = this.filters.length - 1;
    }

    this.mainQuery()
    this.products = this.filteringProducts;
    this.filteringProducts = this.allProducts;
  }

  onSubCategoryCheckbox(event: any) {
    this.filteringProducts = this.allProducts;

    let isChecked = event.target.checked;
    let checkboxValue = event.srcElement.value;
    let foundFlag = false;
    let tempFilterValues: number[] = [];
    let filterIndex = -1;

    //updating genderCategory object with values
    if (this.filters.length > 0) {
      this.filters.forEach((f, index) => {
        if (f.filterName === 'SubCategory') {
          filterIndex = index;
          foundFlag = true;

          if (isChecked) {
            this.filters[index].filterValues.push(checkboxValue);
            tempFilterValues = this.filters[index].filterValues;
          } else {
            let indexDelete;
            indexDelete = this.filters[index].filterValues.indexOf(checkboxValue);
            this.filters[index].filterValues.splice(indexDelete, 1);
          }
        }
      })
    }

    //creating genderCategory object and add value to array from checkboxValue
    if (!foundFlag) {
      tempFilterValues.push(checkboxValue);
      this.filters.push({ filterName: 'SubCategory', filterValues: tempFilterValues })
      filterIndex = this.filters.length - 1;
    }

    this.mainQuery()
    this.products = this.filteringProducts;
    this.filteringProducts = this.allProducts;
  }

  mainQuery() {
    this.filters.forEach((x, index) => {
      switch (x.filterName) {
        case 'GenderCategory': this.GenderCategoryFilter(x.filterValues, x.filterValues.length);
          break;
        case 'Brand': this.BrandFilter(x.filterValues, x.filterValues.length);
          break;
        case 'Color': this.ColorFilter(x.filterValues, x.filterValues.length);
          break;
        case 'SubCategory': this.SubCategoryFilter(x.filterValues, x.filterValues.length);
          break;
        default: this.filteringProducts = this.allProducts;
      }
    });
  }

  private GenderCategoryFilter(filters: number[], numOfElements: number) {
    switch (numOfElements) {
      case 1: this.filteringProducts = this.filteringProducts.filter(x => { return x.genderCategoryId == filters[0] });
        break;
      case 2: this.filteringProducts = this.filteringProducts.filter(x => { return x.genderCategoryId == filters[0] || x.genderCategoryId == filters[1] });
        break;
      case 3: this.filteringProducts = this.filteringProducts.filter(x => { return x.genderCategoryId == filters[0] || x.genderCategoryId == filters[1] || x.genderCategoryId == filters[2] });
        break;
    }
  }

  private BrandFilter(filters: number[], numOfElements: number) {
    switch (numOfElements) {
      case 1: this.filteringProducts = this.filteringProducts.filter(x => { return x.brandId == filters[0] });
        break;
      case 2: this.filteringProducts = this.filteringProducts.filter(x => { return x.brandId == filters[0] || x.brandId == filters[1] });
        break;
      case 3: this.filteringProducts = this.filteringProducts.filter(x => { return x.brandId == filters[0] || x.brandId == filters[1] || x.brandId == filters[2] });
        break;
    }
  }

  private setMessageProperty(products: Product[]) {
    if (products.length == 0)
      this.message = "No results found"
    else
      this.message = '';
  }

  private ColorFilter(filters: number[], numOfElements: number) {
    switch (numOfElements) {
      case 1: this.filteringProducts = this.filteringProducts.filter(x => { return x.colorId == filters[0] });
        break;
      case 2: this.filteringProducts = this.filteringProducts.filter(x => { return x.colorId == filters[0] || x.colorId == filters[1] });
        break;
      case 3: this.filteringProducts = this.filteringProducts.filter(x => { return x.colorId == filters[0] || x.colorId == filters[1] || x.colorId == filters[2] });
        break;
    }
  }

  private SubCategoryFilter(filters: number[], numOfElements: number) {
    switch (numOfElements) {
      case 1: this.filteringProducts = this.filteringProducts.filter(x => { return x.subCategoryId == filters[0] });
        break;
      case 2: this.filteringProducts = this.filteringProducts.filter(x => { return x.subCategoryId == filters[0] || x.subCategoryId == filters[1] });
        break;
      case 3: this.filteringProducts = this.filteringProducts.filter(x => { return x.subCategoryId == filters[0] || x.subCategoryId == filters[1] || x.subCategoryId == filters[2] });
        break;
    }
  }

  ResetFilters() {
    this.products = this.allProducts;
    this.checkboxes.forEach(x => {
      x.nativeElement.checked = false;
    });

    this.filters = [];
  }

}
