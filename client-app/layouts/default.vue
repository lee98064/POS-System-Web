<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app :clipped="false" fixed>
      <v-img
      height="140"
      class="pa-4"
      src="https://upload.cc/i1/2022/02/20/aZvYlH.png"
    >
      <div class="text-center">
        <v-avatar class="mb-4" color="grey darken-1" size="64">
          <v-img
            aspect-ratio="30"
            src="https://yt3.ggpht.com/esazPAO03T0f0vKdByJvkDy6MSwjyG5f-c_2S2CJapszQ3KPQyZarpoqvgv0Us0atUbILytj=s88-c-k-c0x00ffffff-no-rj"
          />
        </v-avatar>
        <h2 class="white--text">Demo User</h2>
      </div>
    </v-img>
    <v-divider></v-divider>

      <v-divider></v-divider>

      <v-list>
        <v-list-item
          v-for="item in links"
          :key="item.icon"
          link
          :to="item.path"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ $t(item.name) }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <template v-slot:append>
        <div class="pa-2">
          <v-select
            :items="optionLang"
            v-model="$store.state.lang"
            item-text="text"
            item-value="value"
            filled
            label="語言"
            dense
            @change="setLang($store.state.lang)"
          ></v-select>
          <v-btn block color="red" @click="logout()">
            {{ $t('logout') }}
          </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
    <v-app-bar fixed app>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>{{ $t('title') }}</v-toolbar-title>
      <v-spacer />
    </v-app-bar>

    <v-main>
      <v-container class="py-8 px-6" fluid>
        <Nuxt />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data() {
    return {
      drawer: true,
      links: [
        {
          name: 'Sidebar.dashboard',
          icon: 'mdi-monitor-dashboard',
          path: '/dashboard',
        },
        // {
        //   name: 'Sidebar.send',
        //   icon: 'mdi-send',
        //   path: '/send',
        // },
        {
          name: 'Sidebar.products',
          icon: 'mdi-shopping',
          path: '/products',
        },
      ],
      optionLang: [
        { text: '中文', value: 'zh', id: 1 },
        { text: 'English', value: 'en', id: 2 },
      ],
    }
  },
  methods: {
    setLang(value) {
      this.$store.commit('setLang', value)
      this.$i18n.locale = value
    },
    logout(){
      localStorage.removeItem('authkey')
      this.$router.push({ name: 'index' })
    }
  },
}
</script>
