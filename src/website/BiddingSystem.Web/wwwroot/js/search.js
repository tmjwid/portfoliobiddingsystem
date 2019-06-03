var timeout;
document.getElementById('search-term').addEventListener('input', function (e) {
    if (timeout != null || timeout != undefined) {
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            search(document.getElementById('search-term').value);
        }, 1000);
    } else {
        timeout = setTimeout(function () {
            search(document.getElementById('search-term').value);
        }, 1000);
    }
});

function search(searchTerm) {
    const client = new XMLHttpRequest();
    const url = "https://" + window.location.hostname + ":" + window.location.port + "/api/subcontractor/";
    client.open("GET", url + searchTerm);
    client.send();
    client.onreadystatechange = (e) => {
        if (client.readyState == 4 && client.status == 200 && client.responseText != "") {
            createSearchList(JSON.parse(client.responseText));
        } else {
            createSearchList(null);
        }
    };
}

function createSearchList(list) {
    var container = document.getElementById('search');
    container.innerHTML = null;
    if (list == null) {
        return;
    }
    list.forEach(function (element, index) {
        if (element.noneFound) {
            var noneFound = document.createElement("div");
            noneFound.className = "mb-2"
            noneFound.innerHTML = "No results found";
            container.appendChild(noneFound);
            return;
        }
        var button = document.createElement("div");
        button.id = element.name + "-button";
        if (index > 0) {
            button.className = "btn btn-primary ml-2 mb-2";
        } else {
            button.className = "btn btn-primary mb-2";
        }
        if (element.disabled) {
            button.classList.add("disabled");
        }
        button.textContent = element.name;
        button.setAttribute('data-id', element.id);
        button.addEventListener('click', function () {
            if (!this.classList.contains("disabled")) {
                addToSelected(this);
            }
        });
        container.appendChild(button);
    });
};

function addToSelected(button) {
    var searchbox = document.getElementById('search-term');
    searchbox.style.display = 'none';
    var resetButton = document.createElement("div");
    resetButton.id = "reset-search";
    resetButton.className = "btn btn-primary mb-2 ml-2";
    resetButton.textContent = "Clear choice";
    resetButton.addEventListener('click', function () {
        resetSearch();
    });
    var container = document.getElementById('search');
    container.appendChild(resetButton);
    button.classList.replace("btn-primary", "btn-success");
    document.getElementById('searchid').value = button.getAttribute('data-id');
};

function resetSearch() {
    var container = document.getElementById('search');
    container.innerHTML = "";
    var searchbox = document.getElementById('search-term');
    searchbox.value = "";
    searchbox.style.display = 'block';
    document.getElementById('searchid').value = "";
}