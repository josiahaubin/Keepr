import swal from 'sweetalert2'
export default class NotificationService {
  // LOGIN
  static toast(text = "", title = text, timer = 4000) {
    swal.fire({
      title,
      type: "success",
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
      position: "top-right",
      toast: true
    })
  }

  static toastCreateKeepError(error) {
    if (error.isAxiosError) {
      error.message = error.response.data
    }
    swal.fire({
      title: "Keep not added",
      type: "error",
      timer: 7000,
      showConfirmButton: false,
      position: "top-right",
      toast: true
    })
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

}