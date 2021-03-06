import { Component, Output, OnInit, EventEmitter } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    @Output()
    sideNavClosed: EventEmitter<any> = new EventEmitter<any>();

    constructor() {}
    ngOnInit(): void {
            
    }


    public closeSideNav() {
        this.sideNavClosed.emit(false); 
    }



}
