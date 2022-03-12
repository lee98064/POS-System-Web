function createApi($axios) {
  return {
    user: {
      login(account, password) {
        return $axios
          .post('/auth/login', {
            account: account,
            password: password
          })
          .then((res) => res)
          .catch((e) => e)
      },
      register(data) {
        console.log(data)
        return $axios
          .post('/auth/register', data)
          .then((res) => res)
          .catch((e) => e)
      },
      logout() {
        return $axios
          .get('/auth/logout')
          .then((res) => res)
          .catch((e) => e)
      },
      isLogin(data) {
        return $axios
          .get('/auth/isLogin', {
            params: {
              "token": localStorage.getItem("authkey")
            }
          })
          .then((res) => res)
          .catch((e) => e)
      },
    },
    products: {
      all() {
        return $axios
          .get('/products/index')
          .then((res) => res)
          .catch((e) => e)
      }
    }
  }
}

import Vue from 'vue'

export default (context, inject) => {
  // 注入Vue實例
  Vue.prototype.$api = createApi(context.$axios)

  // 注入context
  context.app.$api = createApi(context.$axios)

  // 同時注入，前面會自帶$
  inject('api', createApi(context.$axios))
}
