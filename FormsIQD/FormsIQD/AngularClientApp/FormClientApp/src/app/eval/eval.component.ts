import { Component, OnInit } from '@angular/core';
import { myForm } from '../app.model';
import { HttpClient } from "@angular/common/http"
import * as _ from "lodash"; //* means import all, it is old js framework
import { Global } from '../common/common.global';

@Component({
  selector: 'app-eval',
  templateUrl: './eval.component.html',
  styleUrls: ['./eval.component.css']
})
export class EvalComponent implements OnInit {

  title = 'FormClientApp';
  formObj: myForm = new myForm(); //binded with UI
  formList: Array<myForm> = new Array<myForm>(); //collection

  ngOnInit(): void {
    this.GetfromServer();
  }


  //dependancy injection instead of using httpObj:HttpClient = new HttpClient()
  constructor(public httpObj: HttpClient, public globalObj: Global) {

  }


  AddtoServer() {
    //=====to solve circular json error======
    //need to use dto data transfer object, basically we passing formgroup in addition to the id,name,address to mvc and mvc doesn't know what is formgroup. so we create a new dto object that copies the id,name and address only,then in the observable post, we pass this formdto instead of this.formObj
    // var formdto: any = {};
    // formdto.address = this.formObj.address;
    // formdto.customerName = this.formObj.customerName;
    // formdto.id = this.formObj.id;
    // formdto.products = this.formObj.products; //pass the products list from formObj to formdto to send to server

    var formdto: any = _.omit(this.formObj, ['formGroup']); //code on top becomes this, we just want to omit formgroup

    // var formdto:any = {
    //   Id : this.formObj.Id,
    //   customerName : this.formObj.customerName,
    //   address : this.formObj.address
    // };

    //we need to make call to mvc domain https://localhost:44301/
    // var observable = this.httpObj
    //   .post("https://localhost:44301/Customer/Add", formdto); //formdto instead of this.formObj to not include formgroup to mvc as mvc doesn't know what is formgroup

    //webapi changes the url, it will figure out the add/post by itself
    var observable = this.httpObj
      .post(this.globalObj.formUrl, formdto);

    observable.subscribe(
      res => this.SuccessObserver(res),
      res => this.ErrorObserver(res)
    )
  }
  SuccessObserver(res: any) { //res is just a variable, data type any
    // for (let element of res) {
    //   var cust: Customer = new Customer();
    //   cust.id = element.id;
    //   cust.address = element.address;
    //   cust.customerName = element.customerName;
    //   cust.products = element.products
    //   this.formList.push(cust);
    // };


    this.formList = res; //moved on top
    this.formObj = new myForm();
  }

  ErrorObserver(res: any) {
    // for (let i = 0; i < res.error.length; i++) {
    //   this.errorList.push(res.error[i].errorMessage)
    // }
    //this.errorM = JSON.stringify(res.message);
    // this.errorList.push(res.error[0].errorMessage);
    // this.errorList.push(res.error[1].errorMessage);
  }


  GetfromServer() {
    //webapi changes the url, it will figure out the add/post by itself
    var observable = this.httpObj
      .get(this.globalObj.formUrl);

    observable.subscribe(
      res => this.SuccessObserver(res),
      res => this.ErrorObserver(res)
    )
  }


  SearchfromServer(customerName: string) { //search by name instead of id
    //webapi changes the url, it will figure out the add/post by itself
    var observable = this.httpObj
      .get(this.globalObj.formUrl + customerName);

    observable.subscribe(
      res => this.SuccessObserver(res),
      res => this.ErrorObserver(res)
    )
  }

  EditInServer() {
    // var formdto: any = {};
    // formdto.address = this.formObj.address;
    // formdto.customerName = this.formObj.customerName;
    // formdto.id = this.formObj.id;

    var formdto: any = _.omit(this.formObj, ['formGroup']); //code on top becomes this, we just want to omit formgroup

    var observable = this.httpObj
      .put(this.globalObj.formUrl + formdto.id, formdto);

    observable.subscribe(
      res => this.SuccessObserver(res),
      res => this.ErrorObserver(res)
    )
  }

  DeleteInServer(id: number) {

    var observable = this.httpObj
      .delete(this.globalObj.formUrl + id);

    observable.subscribe(
      res => this.SuccessObserver(res),
      res => this.ErrorObserver(res)
    )
  }

  //used for edit to display the customer obj response we get from server, create a new customer obj with a formgroup, then display to the angular UI
  Select(selected: myForm) {
    this.formObj = new myForm();
    this.formObj.id = selected.id;
    this.formObj.EmployeeName = selected.EmployeeName;
    this.formObj.EmployeeCode = selected.EmployeeCode;
    this.formObj.Department = selected.Department;
    this.formObj.Designation = selected.Designation;
    this.formObj.CourseCode = selected.CourseCode;
    this.formObj.CourseName = selected.CourseName;
    this.formObj.CourseStart = selected.CourseStart;
    this.formObj.CourseEnd = selected.CourseEnd;
    this.formObj.Radio1 = selected.Radio1;
    this.formObj.Answer1 = selected.Answer1;
    this.formObj.WillRecommend = selected.WillRecommend;
  }

}
