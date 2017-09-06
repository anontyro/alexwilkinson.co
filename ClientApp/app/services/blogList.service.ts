import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import 'rxjs/add/operator/map';
import { BlogPost } from '../components/blogview/bloglist/blogpost/blogpostmodel';

@Injectable()
export class BlogListService
{
    private readonly _url = "/api/BlogPosts/range/";
    private _originUrl: string;
    private cachedBlogList = new ReplaySubject(1);
    private currentPage = 0;
    private returnLimit = 25;


    constructor(
        private http: Http,
        @Inject('ORIGIN_URL') originUrl: string,
    ) { this._originUrl = originUrl; }

    public getList(forceRefresh?: boolean) {
        
        if (!this.cachedBlogList.observers.length || forceRefresh) {
            this.http.get(this._originUrl+this._url)
                .map(response => response.json() )
                .subscribe(response => {
                    this.cachedBlogList.next(response),
                        error => {
                            this.cachedBlogList.error(error);
                            this.cachedBlogList = new ReplaySubject(1);
                        }
                });
        }
        return this.cachedBlogList;
    }


}

