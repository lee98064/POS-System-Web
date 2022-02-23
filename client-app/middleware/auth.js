export default async function ({ app, redirect }) {
    const isLogin = await app.$api.user.isLogin()
    if (!isLogin.data.status) {
      return redirect('/auth/login')
    }
}
  