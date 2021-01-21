const eventBus = {
    on(event, eventHandler) {
        document.addEventListener(event, (e) => eventHandler(e.detail));
    },
    dispatch(event, data) {
        document.dispatchEvent(new CustomEvent(event, { detail: data }));
    },
    remove(event, eventHandler) {
        document.removeEventListener(event, eventHandler);
    },
};

export default eventBus;


/*
class _EventBus {

    constructor() {
        this.bus = {};
    }

    $off(id) {
       delete this.bus[id];
    }

    $on(id, callback) {
        this.bus[id] = callback;
    }

    $emit(id, ...params) {
        if(this.bus[id])
            this.bus[id](...params);
    }
}

export const EventBus = new _EventBus();
The export const prevent multiple instances, making the class static
* */