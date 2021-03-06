import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import 'materialize-css';
import { MaterializeModule } from 'angular2-materialize';

import { AppComponent } from './app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavBarComponent } from './components/navbar/navbar.component';
import { AboutviewComponent } from './components/aboutview/aboutview.component';
import { BlogviewComponent } from './components/blogview/index';
import { BlogListComponent } from './components/blogview/index';
import { BlogPostComponent } from './components/blogview/index';
import { BlogListService } from './services/index';


export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        FooterComponent,
        HomeComponent,
        NavBarComponent,
        BlogviewComponent,
        BlogListComponent,
        BlogPostComponent,
        AboutviewComponent,
    ],
    imports: [
        MaterializeModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'blog', component: BlogviewComponent },
            { path: 'about', component: AboutviewComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
