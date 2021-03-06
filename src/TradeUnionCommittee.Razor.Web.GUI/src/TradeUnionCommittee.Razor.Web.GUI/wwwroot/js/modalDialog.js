﻿function showModalDialog(errorsList) {

    var iterator = 1;
    var errorMessage = "";
    errorsList.forEach(error => {
        errorMessage += `${iterator}. ${error}\n`;
        iterator++;
    });

    $("#errorModal").remove();
    $("body").append(`<div class="modal" tabindex="-1" role="dialog" id="errorModal">
                              <div class="modal-dialog" role="document">
                                  <div class="modal-content">
                                      <div class="modal-header">
                                          <h5 class="modal-title" style="color: red; font-weight: bold; font-size: 20px;">Сталась помилка</h5>
                                          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                              <span aria-hidden="true">&times;</span>
                                          </button>
                                      </div>
                                      <div class="modal-body">
                                          ${errorMessage}
                                      </div>
                                      <div class="modal-footer">
                                          <button type="button" class="btn btn-primary" data-dismiss="modal">Закрити</button>
                                      </div>
                                  </div>
                              </div>
                          </div>`);
    $("#errorModal").modal("show");
}