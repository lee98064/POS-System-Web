const cookie = require('js-cookie');
export default ({
  app
}, inject) => {
  inject('cookie', cookie)
}
