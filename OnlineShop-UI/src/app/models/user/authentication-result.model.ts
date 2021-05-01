export class AuthenticationResult {
    token!: string;
    success!: boolean;
    errors!: string[];

    constructor(token:string,success:boolean,errors:string[]){
        this.token = token;
        this.success = success;
        this.errors = errors;
    }
}