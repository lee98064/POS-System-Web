export default async function ({
  app,
  redirect
}) {
  if (localStorage.getItem("authkey") === null) {
    return redirect('/auth/login')
  }
  const isLogin = await app.$api.user.isLogin()
  if (!isLogin.data.status) {
    return redirect('/auth/login')
  }
}
