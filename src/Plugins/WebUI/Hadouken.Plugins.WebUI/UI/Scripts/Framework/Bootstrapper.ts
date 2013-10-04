﻿///<reference path="EventListener.ts"/>

module Hadouken {
    export class Bootstrapper {

        constructor() {
        }

        init() {
            console.log("init");

            var eventListener = EventListener.getInstance();

            eventListener.addHandler("connected", (data: any) => {
                console.log("connected");
            });
        }
    }
}