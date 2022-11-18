import { Component } from "@angular/core";
import { Title } from "@angular/platform-browser";
import { ActivatedRoute, Router } from "@angular/router";
import { Location } from '@angular/common';

@Component({ template: '' })
export class PageUtils {
    constructor(
        protected title: Title,
        protected location: Location,
        protected router: Router,
        protected route: ActivatedRoute,
    ) { }

    setTitle(msg: string) {
        msg = msg ? `- ${msg}` : '';
        this.title.setTitle(`Gerenciar Contas Bancárias${msg}`);
    }
}