﻿///<reference path="UI/TorrentsListPage.ts"/>

module Hadouken.Plugins.Torrents {
    export class TorrentsPlugin {
        load(): void {
            console.log('torrents plugin loading');

            this.setupMainMenu();

            return;
        }

        private setupMainMenu(): void {
            var anchor = $('<li><a href="#">Torrents</a></li>');
            anchor.find('a').on('click', (e) => {
                e.preventDefault();

                new Hadouken.Plugins.Torrents.UI.TorrentsListPage().load();
            });

            $('#main-menu').append(anchor);
        }
    }
}

try {
    var plugin = new Hadouken.Plugins.Torrents.TorrentsPlugin();
    plugin.load();
} catch(e) {
    console.log(e);
}