export default {
  addEvent(idComponent, eventName, eventFunction) {
    var component = document.getElementById(idComponent);

    if (component) {
        component.addEventListener(eventName, eventFunction);
    }
  },

  addClick(idComponent, eventFunction) {
   this.addEvent(idComponent, 'click', eventFunction);
  },
  get(id){
    return document.getElementById(id)
  },
  createButton(text, eventCallBack, element, className){
    let button = document.createElement("button");
    button.addEventListener("click", eventCallBack);
    button.innerText = text;
    button.tag = element;
    button.classList.add(className);
    return button;
  },
  createTable(arrayColumns){

    var table = document.createElement('table');
    var thead = document.createElement('thead');
    var tr = document.createElement('tr');

    arrayColumns.forEach(element => {
       var th = document.createElement('th');
       th.innerText = element;
       tr.appendChild(th);
    });

    thead.appendChild(tr);
    table.appendChild(thead);
    table.appendChild(document.createElement('tbody'));

    table.classList.add('styled-table');

    return table;
  },
  addRow(table, values){
    var tbody = table.querySelectorAll('tbody')[0];
    var tr = document.createElement('tr');

    values.forEach(element => {
        let isElement = typeof element == 'object';
        var td = document.createElement('td');
        if(element && isElement){
            td.appendChild(element);

        }else{
            td.innerText = element;

        }
        tr.appendChild(td);
     });

     tbody.appendChild(tr);
  }
};
