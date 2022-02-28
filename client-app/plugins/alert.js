const alert = ($swal) => {
  return {
    success(message) {
      $swal({
        icon: 'success',
        title: message,
        showConfirmButton: false,
        timer: 1000,
      })
    },
    error(message) {
      let showMessage
      switch (message) {
        case 'LOGIN_FAILED':
          showMessage = '登入失敗'
          break
        case 'USERNAME_EXISTED':
          showMessage = '帳號已存在'
          break
        case 'NO_PERMISSION':
          showMessage = '帳號無效'
          break
        case 'OPERATION_FAILED':
          showMessage = '操作失敗'
          break
      }
      $swal({
        icon: 'error',
        title: showMessage,
        showConfirmButton: false,
        timer: 1000,
      })
    },
    confirm(message) {
      return $swal({
        title: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: '取消',
        confirmButtonText: '確定',
      })
    },
  }
}

export default ({
  app
}, inject) => {
  inject('alert', alert(app.$swal))
}
