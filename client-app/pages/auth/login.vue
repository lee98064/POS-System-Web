<template>
  <v-container>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="10">
        <v-card class="elevation-6 mt-10">
          <v-window v-model="step">
            <v-window-item :value="1">
              <v-row>
                <v-col cols="12" md="6">
                  <v-card-text class="mt-12">
                    <h4 class="text-center">Login in to Your Account</h4>
                    <h6 class="text-center grey--text">
                      Log in to your account so you can continue builiding
                      <br />and editing your onboarding flows
                    </h6>
                    <v-row align="center" justify="center">
                      <v-col cols="12" sm="8">
                        <v-text-field
                          label="Account"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          class="mt-16"
                          v-model="account"
                        />
                        <v-text-field
                          label="Password"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          type="password"
                          v-model="password"
                        />
                        <v-row>
                          <v-col cols="12" sm="7">
                            <v-checkbox
                              label="Remember Me"
                              class="mt-n1"
                              color="blue"
                            >
                            </v-checkbox>
                          </v-col>
                          <v-col cols="12" sm="5">
                            <span class="caption blue--text"
                              >Forgot password</span
                            >
                          </v-col>
                        </v-row>
                        <v-btn color="blue" dark block tile @click="login()">Log in</v-btn>

                        <h5 class="text-center grey--text mt-4 mb-3">
                          Or Log in using
                        </h5>
                        <v-btn color="red" v-cloak class="mb-5" dark block tile
                          >Google</v-btn
                        >
                      </v-col>
                    </v-row>
                  </v-card-text>
                </v-col>
                <v-col cols="12" md="6" class="blue rounded-bl-xl">
                  <div style="text-align: center; padding: 180px 0">
                    <v-card-text class="white--text">
                      <h3 class="text-center">Don't Have an Account Yet?</h3>
                      <h6 class="text-center">
                        Let's get you all set up so you can start creating your
                        your first<br />
                        onboarding experience
                      </h6>
                    </v-card-text>
                    <div class="text-center">
                      <v-btn tile outlined dark @click="step++">SIGN UP</v-btn>
                    </div>
                  </div>
                </v-col>
              </v-row>
            </v-window-item>
            <v-window-item :value="2">
              <v-row>
                <v-col cols="12" md="6" class="blue rounded-br-xl">
                  <div style="text-align: center; padding: 180px 0">
                    <v-card-text class="white--text">
                      <h3 class="text-center">Alredy Signed up?</h3>
                      <h6 class="text-center">
                        Log in to your account so you can continue building
                        and<br />
                        editing your onboarding flows
                      </h6>
                    </v-card-text>
                    <div class="text-center">
                      <v-btn tile outlined dark @click="step--">Log in</v-btn>
                    </div>
                  </div>
                </v-col>

                <v-col cols="12" md="6">
                  <v-card-text class="mt-12">
                    <h4 class="text-center">Sign Up for an Account</h4>
                    <h6 class="text-center grey--text">
                      Let's get you all set up so you can start creatin your
                      <br />
                      first onboarding experiance
                    </h6>
                    <v-row align="center" justify="center">
                      <v-col cols="12" sm="8">

                        <v-text-field
                          label="Name"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          v-model="register.name"
                        />
                        <v-text-field
                          label="Account"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          v-model="register.account"
                        />
                        <v-text-field
                          label="Email"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          v-model="register.email"
                        />
                        <v-text-field
                          label="Password"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          type="password"
                          v-model="register.password"
                        />
                        <v-text-field
                          label="Password"
                          outlined
                          dense
                          color="blue"
                          autocomplete="false"
                          type="password"
                          v-model="register.password_vaild"
                        />
                        <v-row>
                          <v-col cols="12" sm="7">
                            <v-checkbox
                              label="I Accept AAE"
                              class="mt-n1"
                              color="blue"
                            >
                            </v-checkbox>
                          </v-col>
                          <v-col cols="12" sm="5">
                            <span class="caption blue--text ml-n4"
                              >Terms &Conditions</span
                            >
                          </v-col>
                        </v-row>
                        <v-btn color="blue" dark block tile @click="signup()">Sign up</v-btn>

                        <h5 class="text-center grey--text mt-4 mb-3">
                          Or Sign up using
                        </h5>
                        <v-btn color="red" v-cloak class="mb-5" dark block tile
                          >Google</v-btn
                        >
                      </v-col>
                    </v-row>
                  </v-card-text>
                </v-col>
              </v-row>
            </v-window-item>
          </v-window>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
// const Cookie = process.client ? require('js-cookie') : undefined;
export default {
  name: 'LoginPage',
  layout: 'auth',
  data: () => ({
    step: 1,
    account: "",
    password: "",
    register:{
      email: "",
      name: "",
      account: "",
      password: "",
      password_vaild: "",
    }
  }),
  props: {
    source: String,
  },
  methods:{
    async login(){
      const res = await this.$api.user.login(this.account, this.password)
      if (res instanceof Error || !res.data.status) {
        return this.$alert.error(res.data.token)
      }
      this.$alert.success('登入成功')
      this.$cookie.set('authToken', res.data.token)
      this.$router.push({ name: 'index' })
    },

    async signup(){
      // const validate = this.$refs.form.validate()
      const res = await this.$api.user.register(this.register)
      if (res instanceof Error || !res.data.status) {
        return this.$alert.error(res.token)
      }
      this.$alert.success('註冊成功')
      localStorage.setItem('authkey', res.data.token)
      this.$router.push({ name: 'dashboard' })
    }
  }
}
</script>
<style scoped>
.v-application .rounded-bl-xl {
  border-bottom-left-radius: 300px !important;
}
.v-application .rounded-br-xl {
  border-bottom-right-radius: 300px !important;
}
</style>
