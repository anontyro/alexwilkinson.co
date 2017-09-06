import { Component } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    private isNavOpen: boolean = false;

    constructor() { }

    public changeSideNavState(changeTo: boolean) {
        console.log(changeTo);
        if (changeTo == true) {
            this.isNavOpen = true;
        } else {
            this.isNavOpen = false;
        }
    }

}
