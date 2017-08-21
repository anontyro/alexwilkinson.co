import { Component, Output, OnInit, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-nav-bar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavBarComponent implements OnInit {
    @Output()
    sideNavClosed: EventEmitter<any> = new EventEmitter<any>();

    constructor() {}
    ngOnInit(): void {
            
    }


    public closeSideNav() {
        this.sideNavClosed.emit(true); 
    }



}
