import {
    NgForm,
    FormGroup,//step1 import these for validations, client side validations
    FormControl,
    Validators,
    FormBuilder,
} from '@angular/forms'


export class myForm {
    id: number = 0;
    EmployeeCode: number = 0;
    EmployeeName: string = "";
    Designation: string = "";
    Department: string = "";
    CourseCode: number = 0;
    CourseName: string = "";
    CourseStart: Date = new Date();
    CourseEnd: Date = new Date();
    Radio1: number = 0;
    Answer1: string = "";
    WillRecommend: boolean = false;

    //step 2 create hte instnace for formgroup
    formGroup: FormGroup;

    constructor() {
        //step 3 use builder to create empty hierachy
        var _builder = new FormBuilder();
        this.formGroup = _builder.group({
            //options: ['1'] //for radio default not working though
        });

        //step 4 add required validation on customer name
        this.formGroup.addControl("formControl", new FormControl('', Validators.required));

        var validationcollection = [];
        validationcollection.push(Validators.required);
        validationcollection.push(Validators.pattern("^[a-zA-Z]{3,10}$"));

        this.formGroup.addControl("formNameControl", new FormControl('', Validators.compose(validationcollection)));

    }
}