import { EventEmitter, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http"
import { Observable } from "rxjs";
import { environment } from '../../../environments/environment';

import { Product } from "src/app/models/product/product.model";
import { ShoeSize } from "src/app/models/product/shoe-size.model";

@Injectable()
export class ProductService {
    selectedProductId: string = '';
    productsChanged = new EventEmitter<Product[]>();
    onSearchProduct = new EventEmitter<any>();
    searchFlag = false;

    baseUrl = environment.baseUrl;
    productUrl: string = 'api/product';
    shoeSizeUrl: string = "api/ShoeSize";
    limit = 20;

    constructor(private http: HttpClient) { }

    get(currentPage: number = 1, numberOfItems: number = 10): Observable<Product[]> {
        return this.http.get<Product[]>(`${this.baseUrl}/${this.productUrl}/${currentPage},${numberOfItems}`);
    }

    getBySearch(categoryId: number, searchValue: string): Observable<Product[]> {
        //without Name parametar
        if (searchValue === 'null' || searchValue === null) {
            this.searchFlag = false;
            return this.http.get<Product[]>(`${this.baseUrl}/${this.productUrl}?CategoryId=${categoryId}&Search=${this.searchFlag}`)
        }

        this.searchFlag = true;
        return this.http.get<Product[]>(`${this.baseUrl}/${this.productUrl}?Name=${searchValue}&CategoryId=${categoryId}&Search=${this.searchFlag}`)
    }

    getByFilter(genderCategory: string, categoryId: number): Observable<Product[]> {
        this.searchFlag = false;
        return this.http.get<Product[]>(`${this.baseUrl}/${this.productUrl}?GenderCategory=${genderCategory}&CategoryId=${categoryId}&Search=${this.searchFlag}`)
    }

    getMostPopular(): Observable<Product[]> {
        return this.http.get<Product[]>(`${this.baseUrl}/${this.productUrl}/popular/ ${this.limit}`);
    }

    getById(id: string): Observable<Product> {
        return this.http.get<Product>(`${this.baseUrl}/${this.productUrl}/${id}`);
    }

    getShoeSizes(): Observable<ShoeSize[]> {
        return this.http.get<ShoeSize[]>(`${this.baseUrl}/${this.shoeSizeUrl}`);
    }

    getShoeSizesById(id: number): Observable<ShoeSize> {
        return this.http.get<ShoeSize>(`${this.baseUrl}/${this.shoeSizeUrl}/${id}`);
    }

    delete(id: string, currentPage: number, numberOfItems: number): void {
        this.http.delete(`${this.baseUrl}/${this.productUrl}/${id}`).subscribe(data => {
            if (data > 0) {
                var newProducts;
                this.get(currentPage, numberOfItems).subscribe((res: Product[]) => {
                    newProducts = res;
                    this.productsChanged.emit(newProducts);
                })
            }
        });
    }

    update(id: string, data: Product) {
        return this.http.put(`${this.baseUrl}/${this.productUrl}/${id}`, data);
    }

    post(data: Product) {
        return this.http.post<Product>(`${this.baseUrl}/${this.productUrl}`, data);
    }
}