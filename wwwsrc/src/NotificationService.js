import swal from 'sweetalert2'
export default class NotificationService {
  static toast(text = "", title = text, timer = 4000) {
    swal.fire({
      title,
      type: "success",
      timer,
      showConfirmButton: false,
      position: "top",
      toast: true
    });
  }

  static toastError(text = "", title = text, timer = 4000) {
    swal.fire({
      title,
      type: "error",
      timer,
      showConfirmButton: false,
      position: "top-right",
      toast: true
    });
  }

  static toastLoginError(error) {
    if (error.isAxiosError) {
      error.message = error.response.data
    }
    swal.fire({
      title: "Please enter a valid email or password",
      type: "error",
      timer: 7000,
      showConfirmButton: false,
      position: "top-end",
      toast: true
    })
  }

  static makePublic() {
    return new Promise((resolve, reject) => {
      const swalWithBootstrapButtons = swal.mixin({
        customClass: {
          confirmButton: 'btn btn-success ml-2',
          cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
      })

      swalWithBootstrapButtons.fire({
        title: 'Are you sure you want to make this public?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, do it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      }).then((result) => {
        if (result.value) {
          swalWithBootstrapButtons.fire(
            'Confirmed!',
            'Your keep has been made public.',
            'success'
          )
          resolve(true)
        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire(
            'Cancelled',
            'Your keep is still private',
            'error'
          )
          resolve(false)
        }
      })
    })
  }

  static delete() {
    return new Promise((resolve, reject) => {
      const swalWithBootstrapButtons = swal.mixin({
        customClass: {
          confirmButton: 'btn btn-success ml-2',
          cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
      })

      swalWithBootstrapButtons.fire({
        title: 'Are you sure you want to delete?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      }).then((result) => {
        if (result.value) {
          swalWithBootstrapButtons.fire(
            'Confirmed!',
            'It has been deleted.',
            'success'
          )
          resolve(true)
        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire(
            'Cancelled',
            'It is safe.',
            'error'
          )
          resolve(false)
        }
      })
    })
  }

}