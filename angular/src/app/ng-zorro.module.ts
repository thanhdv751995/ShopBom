import { NgModule } from '@angular/core';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzStatisticModule } from 'ng-zorro-antd/statistic';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { IconsProviderModule } from './icons-provider.module';

@NgModule({
    exports: [
        IconsProviderModule,
        NzLayoutModule,
        NzMenuModule,
        NzTagModule,
        NzBadgeModule,
        NzTableModule,
        NzCardModule,
        NzSpinModule,
        NzMessageModule,
        NzButtonModule,
        NzSelectModule,
        NzGridModule,
        NzStatisticModule,
        NzInputModule,
        NzModalModule,
    ]
  })
  export class DemoNgZorroAntdModule {
  
  }