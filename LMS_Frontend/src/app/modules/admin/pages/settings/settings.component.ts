import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { SystemConfigService } from 'src/app/core/services/system-config.service';
import { ISystemConfig } from 'src/app/data/models/setting';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
})

export class SettingsComponent implements OnInit {
  public settingsForm!: FormGroup;
  public editMode = false;
  public configKeys = ['MaxBorrowPeriod', 'MaxBorrowLimit', 'PenaltyPerDay'];
  public configsMap = new Map<string, ISystemConfig>();

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private configService: SystemConfigService
  ) { }

  public ngOnInit(): void {
    this.settingsForm = this.fb.group({
      MaxBorrowPeriod: [{ value: 0, disabled: true }, [Validators.required, Validators.min(1)]],
      MaxBorrowLimit: [{ value: 0, disabled: true }, [Validators.required, Validators.min(1)]],
      PenaltyPerDay: [{ value: 0, disabled: true }, [Validators.required, Validators.min(0)]],
    });

    this.loadConfigs();
  }

  public loadConfigs(): void {
    this.configKeys.forEach((key) => {
      this.configService.getConfigByKey(key).subscribe((res) => {
        const numericValue = Number(res.value);
        this.settingsForm.get(key)?.setValue(numericValue);

        const config: ISystemConfig = {
          configKey: res.key,
          configValue: res.value,
        };

        this.configsMap.set(key, config);
      });
    });
  }

  public toggleEdit(): void {
    this.editMode = true;
    this.settingsForm.enable();
  }

  public cancelEdit(): void {
    this.editMode = false;
    this.settingsForm.disable();
    this.loadConfigs();
  }

  public saveSettings(): void {
    if (this.settingsForm.invalid) return;

    const updatedConfigs: ISystemConfig[] = [];

    this.configKeys.forEach((key) => {
      const formValue = this.settingsForm.get(key)?.value;
      const originalConfig = this.configsMap.get(key);
      if (originalConfig) {
        updatedConfigs.push({
          ...originalConfig,
          configValue: formValue.toString(),
        });
      }
    });

    this.configService.updateConfigs(updatedConfigs).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Setting Updated',
          detail: 'Setting is updated for the system.'
        })
        this.editMode = false;
        this.settingsForm.disable();
      },
      error: (err) => {
        console.error('Failed to update settings:', err);
      }
    });
  }
}